import { Page } from "@playwright/test";
import { IPageObject } from './page-object';

exports.AuthorsPage = class AuthorsPage implements IPageObject {

    page: Page;
    url = '/authors';

    table_headers = ['Name', 'Nationality', 'Gender'];

    constructor(page) {
        this.page = page;
    }

    ClickAddAuthorButton = async () => {
        await this.page.getByRole('button', { name: 'Add Author' }).click();
    }
}