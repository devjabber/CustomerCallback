import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CallbackListComponent } from './callback/callback-list/callback-list.component';
import { CallbackNewComponent } from './callback/callback-new/callback-new.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: '', component: CallbackNewComponent },
  { path: 'callback/new', component: CallbackNewComponent },
  { path: 'callback/list', component: CallbackListComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
