import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterModule, Routes } from '@angular/router';
import { NavbarService } from '../navbar.service';
import { Observable } from 'rxjs';
import { Teams } from '../models/teams-model';
import { AuthService } from '../../auth/auth.service';
import { User } from '../../auth/models/user.model';

@Component({
  selector: 'app-navbar',
  imports: [RouterModule, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {

  teams$?: Observable<Teams[]>;
  user?: User;

  constructor(private navbarService: NavbarService,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.teams$ = this.navbarService.getTeams();

    this.authService.user()
      .subscribe({
        next: (response) => {
          this.user = response;
        }
      });
      this.user = this.authService.getUser();
  }

  onLogout(): void {
    this.authService.logout();
    this.router.navigateByUrl('home');
  }

}
