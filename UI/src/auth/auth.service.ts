import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './models/user-model';
import { LoginUser } from './models/login-model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  createUser(data: User): Observable<User>{
    return this.http.post<User>('https://localhost:7219/api/User',data);
  }

  login(data: any): Observable<any>{
    return this.http.post<LoginUser>('https://localhost:7219/api/User/login', data);
  }
}
