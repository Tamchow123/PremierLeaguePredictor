import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Scorer, ScorersResponse } from './models/scorer.model';
import { environment } from '../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class StatsService {


    headers: HttpHeaders = new HttpHeaders().set('X-Auth-Token', environment.apiKey);

  constructor(private http: HttpClient) { }

  getScorers(): Observable<Scorer[]> {
    return this.http
      .get<ScorersResponse>('http://localhost:4200/api/v4/competitions/PL/scorers', {
        headers: this.headers,
      })
      .pipe(
        map(response => response.scorers)
      );
    }

    getTopScorer(): Observable<Scorer> {
      return this.http
        .get<ScorersResponse>('http://localhost:4200/api/v4/competitions/PL/scorers', {
          headers: this.headers,
        })
        .pipe(
          map(response => response.scorers[0])
      );

    }

}
