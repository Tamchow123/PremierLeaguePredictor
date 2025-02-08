import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TablePredictionService } from '../service/table-prediction.service';
import { Teams } from '../../navbar/models/teams-model';
import {CdkDragDrop, DragDropModule, moveItemInArray} from '@angular/cdk/drag-drop';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TablePredictionResponse } from '../models/TablePredictionResponse.model';
import { Router } from '@angular/router';
import { Standing } from '../../table/models/standings-model';
import { TableServiceService } from '../../table/table-service.service';



@Component({
  selector: 'app-table-prediction',
  imports: [CommonModule, DragDropModule],
  templateUrl: './table-prediction.component.html',
  styleUrl: './table-prediction.component.css'
})
export class TablePredictionComponent implements OnInit {

  teams$?: Observable<Teams[]>;
  predictedTeams$?: Observable<TablePredictionResponse[]>;
  realTable$?: Observable<Standing[]>;

  constructor(private tablePredictionService: TablePredictionService,
    private router: Router,
    private tableService: TableServiceService
  ) { }

  ngOnInit(): void {
    // Fetch read standings
    this.realTable$ = this.tableService.getPlTable();

    // Load potential predictions
    this.predictedTeams$ = this.tablePredictionService.getPredictions();
    // Always load the original teams too, in case predictions are empty or not found
    this.teams$ = this.tablePredictionService.getTeams();


  }

  drop(event: CdkDragDrop<Teams[]>): void {
    this.teams$?.subscribe(teams => {
      moveItemInArray(teams, event.previousIndex, event.currentIndex);
      this.teams$ = new Observable(observer => observer.next(teams));
    });

  }

  savePrediction(): void {
    if (!this.teams$) {
      console.error('Teams not found');
      return;
    }

    this.tablePredictionService.createPrediction(this.teams$)
      .subscribe({
        next: () => {
          // Once the save is successful, fetch predictions again
          this.predictedTeams$ = this.tablePredictionService.getPredictions();
        },
        error: err => console.error('Error creating prediction:', err)
      });
  }



}
