import { injectable, inject } from 'tsyringe';
import { GetUserInputPort } from '../ports/input/getUserInputPort';
import { User } from '../../domain/entities/user';

@injectable()
export class GetUserUseCase implements GetUserInputPort {
  constructor(
    @inject('UserRepositoryPort') private userRepository: any
  ) {}

  async execute(input: { id: string }): Promise<User | null> {
    return this.userRepository.findById(input.id);
  }
}
