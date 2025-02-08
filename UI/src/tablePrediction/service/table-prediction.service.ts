import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, Observable, of, switchMap, throwError } from 'rxjs';
import { Teams } from '../../navbar/models/teams-model';
import { AuthService } from '../../auth/auth.service';
import { User } from '../../auth/models/user.model';
import { TablePredictionResponse } from '../models/TablePredictionResponse.model';

@Injectable({
  providedIn: 'root'
})
export class TablePredictionService {

  user?: User;

  constructor(private http: HttpClient,
    private authService: AuthService
  ) { }

  getTeams(): Observable<Teams[]> {
    return this.http.get<Teams[]>('https://localhost:7219/api/Team');
  }

  getPredictions(): Observable<TablePredictionResponse[]> {
    this.user = this.authService.getUser();
    if (!this.user) {
      console.error('User not found');
      // Return an error observable
      return throwError(() => new Error('User not found'));
    }
  
    return this.http
      .get<TablePredictionResponse[]>(`https://localhost:7219/api/TablePrediction/${this.user.email}`)
      .pipe(
        catchError(error => {
          // If it’s a 404 from the server, treat it as "no predictions yet"
          if (error.status === 404) {
            return of<TablePredictionResponse[]>([]);
          }
          // Otherwise, rethrow the error
          return throwError(() => error);
        })
      );
  }

  createPrediction(teams$: Observable<Teams[]>): Observable<any> {
    this.user = this.authService.getUser();
    if (!this.user) {
      console.error('User not found');
      // Return an empty observable or throw an error.
      return EMPTY; // import { EMPTY } from 'rxjs';
    }

    return teams$.pipe(
      switchMap(teams => {
        const tablePrediction = {
          username: this.user?.email,
          predictions: teams.map((team, index) => ({
            position: index + 1,
            team: team.name
          }))
        };

        // Return the HTTP POST as an observable
        return this.http.post('https://localhost:7219/api/TablePrediction', tablePrediction);
      })
    );
  }


}
