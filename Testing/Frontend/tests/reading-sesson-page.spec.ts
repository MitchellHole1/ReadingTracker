import { test, expect } from './helpers';

test.describe('Reading Session Page Tests', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/');
  });

  test('Should load reading session page', async ({ page }) => {
    await expect(page).toHaveTitle(/Reading Tracker/);
    await expect(page.locator('text=Reading Tracker')).toBeVisible();
    await expect(page.getByText('Blood Meridian')).toBeVisible();
    await expect(page.getByText('Suttree')).toBeVisible();
  });

});
