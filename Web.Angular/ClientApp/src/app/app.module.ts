import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsersService } from './users/users.service';
import { UsersComponent } from './users/users.component';
import { ToastService } from './shared/services/toast-service.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastsContainer } from './shared/components/toasts-container/toasts-container.component';
import { UsersDetailComponent } from './users/users-detail/users-detail.component';
import { DepartmentsService } from './shared/services/departments.service';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './shared/services/loading-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsersComponent,
    UsersDetailComponent,
    ToastsContainer,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'users/:id', component: UsersDetailComponent, pathMatch: 'full' },
      { path: 'create-user', component: UsersDetailComponent, pathMatch: 'full' },
      { path: '404', component: PageNotFoundComponent },
      { path: '**', redirectTo: '/404' }
    ]),
    NgbModule,
    NgxSpinnerModule,
    ReactiveFormsModule
  ],
  providers: [
    UsersService,
    DepartmentsService,
    ToastService,
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  entryComponents: [UsersDetailComponent]
})
export class AppModule { }
