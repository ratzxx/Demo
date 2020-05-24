import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { finalize } from 'rxjs/operators';
import { of, Observable, timer, Subscription } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor
{
  timer: Subscription;

    intercept(req: HttpRequest<any>, next: HttpHandler): import("rxjs").Observable<import("@angular/common/http").HttpEvent<any>> {
      this.totalRequests++;
      if (this.timer) {
        this.timer.unsubscribe();
      }

      this.timer = timer(500).subscribe(() => {
        this.spinner.show();
      });

      return next.handle(req).pipe(
        finalize(() => {
          this.totalRequests--;
          if (this.totalRequests === 0) {
            this.spinner.hide();
            if (this.timer) {
              this.timer.unsubscribe();
            }
          }
        })
      );
  }

  private totalRequests = 0;

  constructor(private spinner: NgxSpinnerService) { }

 
}
