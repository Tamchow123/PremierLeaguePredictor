import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { map, Observable, of, switchMap, tap } from 'rxjs';
import { Filters, Season, Standing, StandingsData } from './models/standings-model';
import { Matches } from '../matches/matches/models/matches-model';


@Injectable({
  providedIn: 'root'
})
export class TableServiceService {
  matchDay$?: Observable<Matches[]>;
  currentMatchday: number = 0;


  headers: HttpHeaders = new HttpHeaders().set('X-Auth-Token', environment.apiKey);

  constructor(private http: HttpClient) { }

  getPlTable(): Observable<Standing[]> {
    return this.http
      .get<StandingsData>('http://localhost:4200/api/v4/competitions/PL/standings', {
        headers: this.headers,
      })
      .pipe(
        map((data: StandingsData) => data.standings[0].table) // Extracting the `table` array
      );
  }

  getSeason(): Observable<Season> {
    return this.http
      .get<{ season: Season }>('http://localhost:4200/api/v4/competitions/PL/standings', {
        headers: this.headers,
      })
      .pipe(
        map((data) => data.season) // Extracting the `season` object directly
      );
  }

  getYear(): Observable<Filters> {
    return this.http
      .get<{ filters: Filters }>('http://localhost:4200/api/v4/competitions/PL/standings', {
        headers: this.headers,
      })
      .pipe(
        map((data) => data.filters) // Extracting the `season` object directly
      );
  }



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

// Updated getFixtures() function
getFixtures(): Observable<Matches[]> {
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
          map((response) => response.matches), // Extract the matches array
        );
    })
  );
}






}
