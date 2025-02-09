import { Page } from "@playwright/test";
import { IPageObject } from './page-object';

exports.TrackerPage = class TrackerPage implements IPageObject {

    page: Page;
    url = '/tracker';

    table_headers = ['Book', 'Author', 'Rating', 'Start Date', 'End Date'];

    constructor(page) {
        this.page = page;
    }

    GetCurrentlyReadingBooks = () => {
        return "//div[@class='card']";
    }

    GetRecentlyReadBooks = () => {
        return "//tbody/tr";
    }

}