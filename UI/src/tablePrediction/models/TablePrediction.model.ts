export interface TablePrediction {
    username: string;
    predictions: Teams[];
}

export interface Teams {
    position: number;
    team: string;
}
