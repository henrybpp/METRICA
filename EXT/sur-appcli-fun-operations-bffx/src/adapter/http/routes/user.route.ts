import { FastifyInstance } from "fastify";
import { container } from "../../../infrastructure/di/container";
import { GetUserUseCase } from "../../../application/usecases/getUserUseCase";

export default async function (app: FastifyInstance) {

  app.get("/user/:id", async (request: any, reply) => {
    try {
      const { id } = request.params as { id: string };
      const getUser = container.resolve(GetUserUseCase) as GetUserUseCase;
      const result = await getUser.execute({ id });
      return result;
    } catch (error: any) {
      reply.code(400).send({
        message: error.message
      });
    }
  });
}