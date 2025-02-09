import { test, expect } from './helpers';
const { TrackerPage } = require('../page_objects/tracker-page')

test.describe('Reading Session Page Tests', () => {

  let trackerPage;

  test.beforeEach(async ({ page }) => {
    trackerPage = new TrackerPage(page);
    await page.goto('/');
    await page.getByRole('link', { name: 'Tracker', exact: true }).click();
  });

  test('Should load reading session page', async ({ page }) => {
    await expect(page).toHaveTitle(/Reading Tracker/);
    await expect(page.url()).toContain(trackerPage.url);
    await expect(page.locator('text=Reading Tracker')).toBeVisible();
    await expect(page.locator('text=Currently Reading')).toBeVisible();
    await expect(page.locator('text=Recently Read')).toBeVisible();
  });

  test('Should Display Currently Reading Books', async ({ page }) => {
    await expect(page.locator('text=Currently Reading')).toBeVisible();
    await expect(page.locator(trackerPage.GetCurrentlyReadingBooks())).toHaveCount(2);
  });

  test('Should Display Recently Read Books', async ({ page }) => {
    await expect(page.locator('text=Recently Read')).toBeVisible();
    trackerPage.table_headers.forEach(async (header) => {
      await expect(page.getByText(header, { exact: true })).toBeVisible();
    });
    await expect(page.locator(trackerPage.GetRecentlyReadBooks())).toHaveCount(2);
    await expect(page.getByText('Blood Meridian')).toBeVisible();
    await expect(page.getByText('Suttree')).toBeVisible();
  });

});