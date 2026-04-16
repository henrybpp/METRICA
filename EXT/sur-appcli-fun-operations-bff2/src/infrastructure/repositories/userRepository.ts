import { User } from "domain/entities/user";
import { UserRepositoryPort } from "application/ports/output/userRepositoryPort"; 
import { injectable } from "tsyringe";

@injectable()
export class UserRepository implements UserRepositoryPort { 
    async getUserById(id: string): Promise<User> {            
        return new User(id, "John Doe", "Jhon@gmail.com");
    }
    /*createUser(user: User): Promise<void> {
        throw new Error("Method not implemented.");
    }   
    updateUser(user: User): Promise<void> {
        throw new Error("Method not implemented.");
    }
    deleteUser(id: string): Promise<void> {
        throw new Error("Method not implemented.");
    }*/
}   
  
