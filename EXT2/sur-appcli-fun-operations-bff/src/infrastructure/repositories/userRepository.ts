import { injectable } from 'tsyringe';
import { User } from '../../domain/entities/user';
import { UserRepositoryPort } from '../../application/ports/output/userRepositoryPort';

@injectable()
export class UserRepository implements UserRepositoryPort {
  private users: User[] = [
    new User('1', 'Alice'),
    new User('2', 'Bob')
  ];

  async findById(id: string): Promise<User | null> {
    return this.users.find(u => u.id === id) || null;
  }
}
