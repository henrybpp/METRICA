import { User } from '../entities/user';   
import { injectable } from "tsyringe"

@injectable()
export class UserService {
    validateUser(user: User): boolean {
      if(!user.id || !user.name || !user.email){
        return false;
      }
      return true;
    }
}
