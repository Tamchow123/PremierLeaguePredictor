import { CommonModule } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../auth.service';
import { RegisterRequest } from '../../models/register-request.model';

@Component({
  selector: 'app-register',
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  @ViewChild('form') registerForm!: NgForm; // Get reference to form

  model: RegisterRequest = {
    email: '',
    password: ''
  };

  confirmPassword: string = '';
  errorMessage: string = '';
  passwordMismatch: boolean = false;

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  // Called when user clicks "Register" and form is valid
  onFormSubmit() {
    // Double-check in case the user bypassed client-side checks
    if (this.passwordMatch()) {
      this.errorMessage = 'Passwords do not match';
      return;
    }

    // All checks OK, proceed to register
    this.authService.register(this.model).subscribe({
      next: () => {
        // On success, navigate away
        this.router.navigateByUrl('login');
      },
      error: (errorResponse) => {
        // Check if it's a 400 and has the expected structure
        if (
          errorResponse.status === 400 &&
          errorResponse.error &&
          errorResponse.error.errors
        ) {
          // Check for “DuplicateUserName” from the response
          const errors = errorResponse.error.errors;
          if (errors['DuplicateUserName']) {
            // Use the message from the API
            this.errorMessage = errors['DuplicateUserName'][0];
          }
        } else {
          // Fallback for other status codes or response formats
          this.errorMessage = 'Registration failed';
        }
      }
    });
  }

  // Returns true if mismatch, false if match
  passwordMatch(): boolean {
    return this.model.password !== this.confirmPassword;
  }
}
