import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarService } from '../navbar.service';
import { Observable} from 'rxjs';
import { Teams } from '../models/teams-model';

@Component({
  selector: 'app-navbar',
  imports: [RouterModule, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {

  teams$?: Observable<Teams[]>;

  constructor(private navbarService: NavbarService ) { }

  ngOnInit(): void {
    this.teams$ = this.navbarService.getTeams();
  }

}
