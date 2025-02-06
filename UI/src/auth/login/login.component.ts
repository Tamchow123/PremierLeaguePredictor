import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { CookieService } from 'ngx-cookie-service';
import { LoginRequest } from '../models/login-request.model';


@Component({
  selector: 'app-login',
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  model: LoginRequest;

  constructor(private authService: AuthService,
    private router: Router,
    private cookieService: CookieService
  ){
    this.model = {
      email: '',
      password: ''
    }
  }


  onFormSubmit(): void {
    this.authService.login(this.model)
    .subscribe({
      next: (response) => {
        // Set Auth Cookie
        this.cookieService.set('Authorization', `Bearer ${response.token}`,
          undefined, '/', undefined, true, 'Strict');

          // Set User
          this.authService.setUser({
            email: response.email,
            roles: response.roles
          })
          
          // Redirect to home
          this.router.navigateByUrl('home');
        }
    });
  }




}
