import { container } from 'tsyringe';
import { GetUserUseCase } from '../../application/usecases/getUserUseCase';
import { UserRepository } from '../repositories/userRepository';

container.register('UserRepositoryPort', { useClass: UserRepository });
container.register('GetUserUseCase', { useClass: GetUserUseCase });

export { container };
