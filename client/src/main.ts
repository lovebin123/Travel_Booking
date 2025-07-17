/// <reference types="@angular/localize" />

import { bootstrapApplication, provideClientHydration } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { authInterceptorFn } from './app/services/Interceptor/auth-interceptor.interceptor';
bootstrapApplication(AppComponent, {
  providers:[provideRouter(routes),provideHttpClient(withInterceptors([authInterceptorFn]))],
});
