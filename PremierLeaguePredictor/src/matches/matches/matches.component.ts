import { Component, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Matches } from './models/matches-model';
import { TableComponent } from '../../table/table/table.component';
import { TableServiceService } from '../../table/table-service.service';
import { CommonModule } from '@angular/common';
import { MatchesService } from '../matches.service';




@Component({
  selector: 'app-matches',
  imports: [CommonModule],
  templateUrl: './matches.component.html',
  styleUrl: './matches.component.css'
})
export class MatchesComponent implements OnInit {

  matches$?: Observable<Matches[]>;
  currentMatchday: number = 0;
  tempDate: string = '';
  showDate: string = '';
  getMatchdaySubscription?: Subscription;

  constructor(private matchService: MatchesService) { }

  ngOnInit(): void {
    this.matches$ = this.matchService.getFixtures();
    this.getMatchdaySubscription =this.matchService.getMatchDay().subscribe(matchday => this.currentMatchday = matchday);

  }

  shouldUpdateDate(newDate: string): boolean {
    newDate = newDate.substring(0, 10);
    this.tempDate = this.tempDate.substring(0, 10);

    if (newDate !== this.tempDate) {
      this.tempDate = newDate;
      this.showDate= new Date(this.tempDate).toDateString();
      return true;
    }
    return false;
  }

  nextMatchday(): void {
    this.currentMatchday++;
    this.matches$ = this.matchService.getFixtures(this.currentMatchday);
  }

  previousMatchday(): void {
    this.currentMatchday--;
    this.matches$ = this.matchService.getFixtures(this.currentMatchday);
  }

  ngOnDestroy(): void {
    this.getMatchdaySubscription?.unsubscribe();
  }




}
