﻿import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { UserRepositoryRoleViewModel } from './model/userRepositoryRole-view-model';

/**
 * 编辑
 */
@Component({
    selector: 'userRepositoryRole-edit',
    templateUrl: env.prod() ? './html/userRepositoryRole-edit.component.html' : '/view/dbo/userRepositoryRole/edit'
})
export class UserRepositoryRoleEditComponent extends EditComponentBase<UserRepositoryRoleViewModel> {
    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 创建视图模型
     */
    protected createModel() {
        return new UserRepositoryRoleViewModel();
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "userRepositoryRole";
    }
}