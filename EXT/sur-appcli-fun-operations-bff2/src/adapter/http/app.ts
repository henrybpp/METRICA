import Fastify, { FastifyInstance } from "fastify";
import userRoutes from "./routes/user.route";
import "../../infrastructure/di/container"; // Asegura que el contenedor de DI esté configurado 

export default function buildApp(): FastifyInstance {
  const app = Fastify({
    logger: true
  });

  // Registro de rutas
  app.register(userRoutes);
  //app.register(clientRoutes);
  return app;
}