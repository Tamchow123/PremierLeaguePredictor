import { CommonModule } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../auth.service';
import { User } from '../../models/user-model';

@Component({
  selector: 'app-register',
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  @ViewChild('form') registerForm!: NgForm; // Get reference to form


  model: User;
  confirmPassword: string = '';
  errorMessage: string = '';
  passwordMismatch: boolean = true;
  passwordShort: boolean = true;

  constructor(private authService: AuthService,
    private router: Router
  ){
    this.model = {
      username: '',
      email: '',
      passwordHash: '',
      createdDate:  new Date().toISOString()
    };
  }



  passwordMatch(): boolean {
    return this.model.passwordHash !== this.confirmPassword;
  }

  passwordLength(): boolean {
    return this.model.passwordHash.length < 8;
  }


  onFormSubmit(){
    this.passwordMismatch = this.passwordMatch();
    this.passwordShort = this.passwordLength();

    if (this.passwordMismatch) {
      return;
    }
    else if (this.passwordShort) {
      return;
    }
    else{
      this.errorMessage = '';
    }

    if (this.registerForm.invalid || this.passwordMismatch) {
      return;
    }

    this.model.createdDate = new Date().toISOString();
    this.authService.createUser(this.model).subscribe({
      next: (response) => {
        this.router.navigate(['/login']);
      },
      error: (error) => {
        if (error.status === 409) {
          this.errorMessage = "A user with this email already exists. Please use a different email.";
        } else {
          this.errorMessage = "An error occurred while creating your account. Please try again.";
        }
      }
    })
  }

}
