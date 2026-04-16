
import buildApp from "@/adapter/http/app";

const app = buildApp();


export default async function (context: any, req: any): Promise<void> {
  try {
    const url = toFastifyUrl(req);
    const response = await app.inject({
      method: req.method,
      url,
      headers: req.headers,
      payload: req.body
    });

    context.res = {
      status: response.statusCode,
      body: parseBody(response),
      headers: response.headers
    };

  } catch (error: any) {
    context.log.error("Unhandled error:", error);

    context.res = {
      status: 500,
      body: {
        message: "Internal Server Error"
      }
    };
  }
}

function toFastifyUrl(req: any): string {
  // In Azure Functions, `req.url` is typically an absolute URL and includes the default
  // routePrefix `/api`. Our Fastify routes are defined without that prefix.
  const rawUrl: string | undefined = req?.url;

  if (!rawUrl) {
    return req?.originalUrl ?? "/";
  }

  let parsed: URL;
  try {
    parsed = new URL(rawUrl);
  } catch {
    // If `req.url` is already a path (or malformed), fall back to it as-is.
    return rawUrl;
  }

  const pathname = parsed.pathname.replace(/^\/api(?=\/|$)/, "") || "/";
  return `${pathname}${parsed.search}`;
}

/**
 * Evita problemas cuando Fastify devuelve string JSON
 */
function parseBody(response: any) {
  try {
    return JSON.parse(response.payload);
  } catch {
    return response.payload;
  }
}