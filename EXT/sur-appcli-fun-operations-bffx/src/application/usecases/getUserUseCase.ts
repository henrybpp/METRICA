import { GetUserInputPort } from 'application/ports/input/getUserInputPort';
import { UserRepositoryPort } from 'application/ports/output/userRepositoryPort';
import { User } from 'domain/entities/user';
import { UserService } from 'domain/services/userService';
import { inject, injectable } from 'tsyringe';

@injectable()
export  class GetUserUseCase implements GetUserInputPort {
  constructor(
    @inject("UserRepositoryPort")
    private port: UserRepositoryPort,
    @inject(UserService)
    private userService: UserService
  ) {}  
  async execute(input: { id: string }): Promise<User | null> {
    if (!input.id) throw new Error('ID is required');
    const user = await this.port.getUserById(input.id);
    if (!user) throw new Error('User not found');
    if (!this.userService.validateUser(user)) throw new Error('Invalid user data');
    return user;
  }
}
