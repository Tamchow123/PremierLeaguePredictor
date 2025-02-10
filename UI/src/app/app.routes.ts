import { Routes } from '@angular/router';
import { TableComponent } from '../table/table/table.component';
import { MatchesComponent } from '../matches/matches/matches.component';
import { StatsComponent } from '../stats/stats.component';
import { LoginComponent } from '../auth/login/login.component';
import { RegisterComponent } from '../auth/register/register/register.component';
import { HomeComponent } from '../homepage/home/home.component';
import { TablePredictionComponent } from '../tablePrediction/table-prediction/table-prediction.component';
import { FixturePredictionComponent } from './fixturePrediction/fixture-prediction/fixture-prediction.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'table', component: TableComponent },
  { path: 'matches', component: MatchesComponent },
  { path: 'stats', component: StatsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'login/register', component: RegisterComponent },
  { path: 'home', component: HomeComponent },
  { path: 'tablePredictions', component: TablePredictionComponent },
  { path: 'fixturePredictions', component: FixturePredictionComponent }


];
