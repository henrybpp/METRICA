export = {
  host: process.env.DARWIN_FASTIFY_HOST || '0.0.0.0',
  // FUNCTIONS_CUSTOMHANDLER_PORT is injected by Azure Functions runtime
  port: Number(process.env.FUNCTIONS_CUSTOMHANDLER_PORT) || Number(process.env.DARWIN_FASTIFY_PORT) || 8080
}
