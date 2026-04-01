import 'reflect-metadata';
import { GetUserInputPort } from 'application/ports/input/getUserInputPort';
import { UserRepositoryPort } from 'application/ports/output/userRepositoryPort';
import { UserService } from 'domain/services/userService';
import { container } from 'tsyringe';
import { GetUserUseCase } from '../../application/usecases/getUserUseCase';
import { UserRepository } from '../repositories/userRepository';

container.register<UserRepositoryPort>('UserRepositoryPort', { useClass: UserRepository });
container.register(UserService, { useClass: UserService });
container.register('GetUserUseCase', { useClass: GetUserUseCase });

export { container };