import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ChartType, Row } from 'angular-google-charts';
import { ReplaySubject, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { DateTime } from 'luxon';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

    public LineChart = ChartType.LineChart;

    public Data$: Subject<Row[]> = new ReplaySubject(1);

    constructor(private http: HttpClient) {
    }

    public ngOnInit(): void {
        this.http.get<any[]>('/api/Records')
        .pipe(
            map(results => results.map(({ t, h, z}) => ( { 'z' : DateTime.fromSeconds(z), h, t }))),
            map(results => results.map(row => ([ row.z.toJSDate(), row.h, row.t ]))),
        )
        .subscribe({
            next: results => this.Data$.next(results)
        });
    }
}
