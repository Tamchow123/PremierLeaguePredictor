import { Component, OnInit } from '@angular/core';
import { StatsService } from './stats.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Scorer } from './models/scorer.model';

@Component({
  selector: 'app-stats',
  imports: [CommonModule, FormsModule],
  templateUrl: './stats.component.html',
  styleUrl: './stats.component.css'
})
export class StatsComponent implements OnInit {

  scorers$?: Observable<Scorer[]>;


  constructor(private statsService: StatsService) { }


  ngOnInit(): void {
    this.scorers$ = this.statsService.getScorers();
  }

}
