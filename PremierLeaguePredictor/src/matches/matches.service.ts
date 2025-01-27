import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { map, Observable, of, switchMap, tap } from 'rxjs';
import { Matches } from '../matches/matches/models/matches-model';

@Injectable({
  providedIn: 'root'
})
export class MatchesService {

  currentMatchday: number = 0;


  headers: HttpHeaders = new HttpHeaders().set('X-Auth-Token', environment.apiKey);


  constructor(private http: HttpClient) { }

  getMatchDay(): Observable<number> {
    return this.http
      .get<{ matches: Matches[] }>('http://localhost:4200/api/v4/competitions/PL/matches?matchday=1', {
        headers: this.headers,
      })
      .pipe(
        map((response) => response.matches), // Extract the matches array
        map((matches) => matches[0]?.season.currentMatchday), // Get current matchday from the first match
      );
  }

  getFixtures(matchDay?: number): Observable<Matches[]> {
    // If matchDay is provided, directly use it in the API call
    if (matchDay !== undefined) {
      return this.http
        .get<{ matches: Matches[] }>(
          `http://localhost:4200/api/v4/competitions/PL/matches?matchday=${matchDay}`,
          {
            headers: this.headers,
          }
        )
        .pipe(
          map((response) => response.matches) // Extract the matches array
        );
    }

    // Otherwise, fetch the current match day and proceed
    return this.getMatchDay().pipe(
      switchMap((currentMatchday) => {
        if (!currentMatchday) {
          console.error('No current matchday found!');
          return of([]); // Return an empty array if no matchday is available
        }

        return this.http
          .get<{ matches: Matches[] }>(
            `http://localhost:4200/api/v4/competitions/PL/matches?matchday=${currentMatchday}`,
            {
              headers: this.headers,
            }
          )
          .pipe(
            map((response) => response.matches) // Extract the matches array
          );
      })
    );
  }

}
