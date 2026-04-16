import { User } from '../../../domain/entities/user';

export interface UserRepositoryPort {
  findById(id: string): Promise<User | null>;
}
