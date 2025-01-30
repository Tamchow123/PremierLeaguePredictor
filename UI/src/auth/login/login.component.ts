import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { User } from '../models/user-model';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { LoginUser } from '../models/login-model';

@Component({
  selector: 'app-login',
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  model: LoginUser;

  constructor(private authService: AuthService,
    private router: Router
  ){
    this.model = {
      email: '',
      passwordHash: ''
    };
  }




  ngOnInit(): void {
  }

  onFormSubmit(){
    this.authService.login(this.model).subscribe({
      next: (response) => {
        this.router.navigate(['/table']);
      }
    }

    );
  }

  ngOnDestroy(){
  }


}
