import { Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from "../navbar/navbar/navbar.component";

@Component({
  selector: 'app-root',
  imports: [RouterModule, NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'PremierLeaguePredictor';
}
