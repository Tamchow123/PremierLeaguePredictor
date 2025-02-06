import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TablePredictionService } from '../service/table-prediction.service';
import { Teams } from '../../navbar/models/teams-model';
import {CdkDragDrop, DragDropModule, moveItemInArray} from '@angular/cdk/drag-drop';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-table-prediction',
  imports: [CommonModule, DragDropModule],
  templateUrl: './table-prediction.component.html',
  styleUrl: './table-prediction.component.css'
})
export class TablePredictionComponent implements OnInit {

  teams$?: Observable<Teams[]>;
  teamsLocal$?: Observable<Teams[]>;

  constructor(private tablePredicitonService: TablePredictionService) { }

  ngOnInit(): void {
    this.teams$ = this.tablePredicitonService.getTeams();
  }

  drop(event: CdkDragDrop<Teams[]>): void {
    this.teams$?.subscribe(teams => {
      moveItemInArray(teams, event.previousIndex, event.currentIndex);
      this.teams$ = new Observable(observer => observer.next(teams));

      this.teams$?.subscribe(teams => {
        console.log('Updated teams order:', teams);
      });
    });
    
  }


}
