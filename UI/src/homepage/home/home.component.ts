import { Component, OnInit } from '@angular/core';
import { MatchesService } from '../../matches/matches.service';
import { Matches } from '../../matches/matches/models/matches-model';
import { CommonModule } from '@angular/common';
import { StatsService } from '../../stats/stats.service';
import { Scorer } from '../../stats/models/scorer.model';


@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  upcomingMatches: Matches[] = [];
  topScorer?: Scorer;


  constructor(private matchService: MatchesService,
    private statService: StatsService,
  ) { }

  ngOnInit(): void {
    this.matchService.getFixtures().subscribe({
      next: (matches: Matches[]) => {
        const now = Date.now();
        this.upcomingMatches = matches.filter(match =>
          new Date(match.utcDate).getTime() > now
        );
      },
      error: err => {
        console.error('Error fetching matches:', err);
      }
    });

    this.statService.getTopScorer().subscribe({
      next: (scorer) => {
        this.topScorer = scorer;
      },
      error: (err) => {
        console.error('Error fetching scorers:', err);
      }
    });
  }
}
