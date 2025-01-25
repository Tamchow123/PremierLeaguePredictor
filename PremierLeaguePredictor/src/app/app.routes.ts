import { Routes } from '@angular/router';
import { TableComponent } from '../table/table/table.component';
import { MatchesComponent } from '../matches/matches/matches.component';

export const routes: Routes = [
  { path: 'table', component: TableComponent },
  { path: 'matches', component: MatchesComponent }
];
