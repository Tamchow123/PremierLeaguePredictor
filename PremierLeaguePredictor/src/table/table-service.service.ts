import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { map, Observable } from 'rxjs';
import { Filters, Season, Standing, StandingsData } from './models/standings-model';


@Injectable({
  providedIn: 'root'
})
export class TableServiceService {
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




}
