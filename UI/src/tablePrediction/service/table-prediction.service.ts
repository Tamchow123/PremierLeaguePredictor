import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Teams } from '../../navbar/models/teams-model';

@Injectable({
  providedIn: 'root'
})
export class TablePredictionService {

  constructor(private http: HttpClient) { }

  getTeams(): Observable<Teams[]> {
    return this.http.get<Teams[]>('https://localhost:7219/api/Team');
  }

  updateTeams(teams: Teams[]) {
    
  }
}
