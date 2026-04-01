
import { User } from "domain/entities/user";    

export interface UserRepositoryPort {
  getUserById(id: string): Promise<User>;
  /*createUser(user: User): Promise<void>;
  updateUser(user: User): Promise<void>;
  deleteUser(id: string): Promise<void>;*/
}   
