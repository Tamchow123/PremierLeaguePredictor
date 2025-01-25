import { Component, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Matches } from './models/matches-model';
import { TableComponent } from '../../table/table/table.component';
import { TableServiceService } from '../../table/table-service.service';
import { CommonModule } from '@angular/common';




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

  constructor(private tableService: TableServiceService) { }

  ngOnInit(): void {
    this.matches$ = this.tableService.getFixtures();
    this.getMatchdaySubscription =this.tableService.getMatchDay().subscribe(matchday => this.currentMatchday = matchday);

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

  ngOnDestroy(): void {
    this.getMatchdaySubscription?.unsubscribe();
  }




}
