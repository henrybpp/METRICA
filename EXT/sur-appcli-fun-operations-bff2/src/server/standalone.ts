import buildApp from "@/adapter/http/app";
import userRoutes from "@/adapter/http/routes/user.route";

async function main() {
  const app = buildApp();

  // Alias routes under /api for local testing parity with Azure Functions routePrefix.
  app.register(userRoutes, { prefix: "/api" });

  const port = process.env.PORT ? Number(process.env.PORT) : 3000;
  const host = process.env.HOST ?? "0.0.0.0";

  await app.listen({ port, host });
}

main().catch((error) => {
  // eslint-disable-next-line no-console
  console.error(error);
  process.exit(1);
});
