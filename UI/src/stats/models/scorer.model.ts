
export interface ScorersResponse {
  count: number;
  filters: Filters;
  competition: Competition;
  season: Season;
  scorers: Scorer[];
}

export interface Filters {
  season: string;
  limit: number;
}

export interface Competition {
  id: number;
  name: string;
  code: string;
  type: string;
  emblem: string;
}

export interface Season {
  id: number;
  startDate: string;
  endDate: string;
  currentMatchday: number;
  winner: string | null;
}

// Single scorer entry
export interface Scorer {
  player: Player;
  team: Team;
  playedMatches: number;
  goals: number;
  assists: number;
  penalties: number;
}

export interface Player {
  id: number;
  name: string;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  nationality: string;
  section: string;
  position: string | null;
  shirtNumber: number | null;
  lastUpdated: string;
}

export interface Team {
  id: number;
  name: string;
  shortName: string;
  tla: string;
  crest: string;
  address: string;
  website: string;
  founded: number;
  clubColors: string;
  venue: string;
  lastUpdated: string;
}
