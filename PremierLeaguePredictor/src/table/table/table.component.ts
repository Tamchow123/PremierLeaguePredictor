import { Component, OnInit } from '@angular/core';
import { TableServiceService } from '../table-service.service';
import { Observable, Subscription } from 'rxjs';
import { Filters, Season, Standing } from '../models/standings-model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-table',
  imports: [CommonModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent implements OnInit {

  standings$?: Observable<Standing[]>; // Observable for async pipe#
  season$?: Observable<Season>;
  filter$?: Observable<Filters>;

  tableSubscription?: Subscription;

  constructor(private tableService: TableServiceService)
  {

  }


  ngOnInit(): void {
        this.standings$ = this.tableService.getPlTable(); // Assign Observable
        this.season$ = this.tableService.getSeason();
        this.filter$ = this.tableService.getYear();

  }

  ngOnDestroy(): void {

  }



}
