import { AfterViewInit, Component, Inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, PageEvent, Sort } from '@angular/material';
import { Subscription } from 'rxjs';
import { DataModel } from 'src/models/data.model';
import { GoodRequestModel } from 'src/models/good-request.model';
import { GoodResult, GoodResultData } from 'src/models/good-result.model';
import { HttpProxyService } from 'src/services/http-proxy.service';
import { BaseComponent } from '../base-component';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.scss']
})
export class FetchDataComponent extends BaseComponent {
  public data: GoodResult;
  public dataSource: MatTableDataSource<DataModel>;
  public displayedColumns: string[] = ['code', 'title', 'manufacturer', 'description', 'price', 'stock'];

  public pageSize = 25;
  public page = 0;
  public dataLoaded = false;

  public title: string = '';
  public description: string = '';
  public manufacturer: string = '';
  private sortField: string = '';
  private sortDirection: string = '';
  
  constructor(
    private httpProxy: HttpProxyService) {
      super();
  }

  private refresh() {
    const requestPars: GoodRequestModel = new GoodRequestModel();
    requestPars.filter = this.title;
    requestPars.orderby = this.sortField;
    requestPars.expand = '';
    requestPars.orderDirection = this.sortDirection;
    requestPars.take = this.pageSize;
    requestPars.skip = this.page * this.pageSize;;

    this.error = null;
    this.isLoading = true;
    this.httpProxy.getData(requestPars).subscribe(response => {
      if (response) {
        this.data = response;
        this.dataSource = new MatTableDataSource<DataModel>([...this.data.result.items]);
        this.isLoading = false;
        this.dataLoaded = true;
      }
    }, error => this.showError(error));
  }

  public handlePageEvent(e: PageEvent) {
    this.page = e.pageIndex;
    this.refresh();
  }

  public sortData(sort: Sort) {
    this.sortField = sort.active;
    this.sortDirection = sort.direction;
    this.refresh();
  }
}
