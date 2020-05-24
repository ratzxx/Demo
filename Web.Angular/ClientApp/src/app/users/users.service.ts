import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IUsers } from '../shared/models/users.model';
import { IUser } from '../shared/models/user.model';

@Injectable()
export class UsersService {
  private usersUrl: string = '';

  constructor(private http: HttpClient) {
    this.usersUrl = 'https://userapi20200524084750.azurewebsites.net/users';
  }

  getUser(userId: number): Observable<IUser> {
    return this.http.get<IUser>(`${this.usersUrl}/${userId}`);
  }

  getUsers(): Observable<IUsers> {
    return this.http.get<IUsers>(this.usersUrl);
  }

  dropUser(userId: number) {
    return this.http.delete(`${this.usersUrl}/${userId}`);
  }

  updateUser(user: IUser) {
    return this.http.put<IUser>(`${this.usersUrl}/${user.id}`, user);
  }

  createUser(user: IUser) {
    return this.http.post<IUser>(this.usersUrl, user);
  }
}
