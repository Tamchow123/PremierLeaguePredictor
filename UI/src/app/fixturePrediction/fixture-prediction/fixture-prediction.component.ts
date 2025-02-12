import { Component } from '@angular/core';
import { MatchesService } from '../../../matches/matches.service';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { Matches } from '../../../matches/matches/models/matches-model';

@Component({
  selector: 'app-fixture-prediction',
  imports: [CommonModule],
  templateUrl: './fixture-prediction.component.html',
  styleUrl: './fixture-prediction.component.css'
})
export class FixturePredictionComponent {

  matches$?: Observable<Matches[]>;

  constructor(private matchService: MatchesService) { }

  ngOnInit(): void {
    this.matches$ = this.matchService.getUpcomingFixtures();
  }
}
