import { User } from "domain/entities/user";

export interface GetUserInputPort {
  execute(input: { id: string } ): Promise<User | null>;
}
  