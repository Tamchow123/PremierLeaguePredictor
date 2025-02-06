import { Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { NavbarComponent } from "../navbar/navbar/navbar.component";

@Component({
  selector: 'app-root',
  imports: [RouterModule, NavbarComponent, DragDropModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'PremierLeaguePredictor';
}
