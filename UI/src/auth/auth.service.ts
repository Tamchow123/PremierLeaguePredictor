import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from './models/user.model';
import { CookieService } from 'ngx-cookie-service';
import { LoginRequest } from './models/login-request.model';
import { LoginResponse } from './models/login-response.model';
import { environment } from '../environments/environment.development';
import { RegisterRequest } from './models/register-request.model';



@Injectable({
  providedIn: 'root'
})
export class AuthService {

  $user = new BehaviorSubject<User | undefined>(undefined)
;
  constructor(private http: HttpClient,
    private cookieService: CookieService
    ) { }

    // Login related:

    login(request: LoginRequest): Observable<LoginResponse>{
      return this.http.post<LoginResponse>(`https://localhost:7219/api/Auth/login`, {
        email: request.email,
        password: request.password
      });
    }

    setUser(user: User): void {
      this.$user.next(user);
      localStorage.setItem('user-email', user.email);
      localStorage.setItem('user-roles', user.roles.join(','));
    }

    user() : Observable<User | undefined> {
      return this.$user.asObservable();
    }

    getUser(): User | undefined{
      const email = localStorage.getItem('user-email');
      const roles = localStorage.getItem('user-roles');

      if(email && roles){
        const user: User = {
          email: email,
          roles: roles?.split(',')
        };

        return user;
      }
      return undefined;
    }

    logout(): void{
      localStorage.clear();
      this.cookieService.delete('Authorization', '/');
      this.$user.next(undefined);
    }


    // Register related:


    register(request: RegisterRequest): Observable<RegisterRequest>{
      return this.http.post<RegisterRequest>(`https://localhost:7219/api/Auth/register`, {
        email: request.email,
        password: request.password
      });
    }

}
