import { CommonModule } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../auth.service';


@Component({
  selector: 'app-register',
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  @ViewChild('form') registerForm!: NgForm; // Get reference to form


  confirmPassword: string = '';
  errorMessage: string = '';
  passwordMismatch: boolean = true;
  passwordShort: boolean = true;

  constructor(private authService: AuthService,
    private router: Router
  ){

  }





  onFormSubmit(){

  }

}
