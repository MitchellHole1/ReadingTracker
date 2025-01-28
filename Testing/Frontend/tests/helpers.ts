// tests/helpers.ts
import { test as _test, expect } from '@playwright/test';
import os from 'os';

export const test = _test.extend<{ _autoAttachMetadata: void }>({
    _autoAttachMetadata: [async ({ browser, browserName }, use, testInfo) => {
        // BEFORE: Generate an attachment for the test with the required info
        await testInfo.attach('metadata.json', {
            body: JSON.stringify({
                name: browserName,
                version: browser.version(),
            })
        })

        // ---------------------------------------------------------
        await use(/** our test doesn't need this fixture direcly */);
        // ---------------------------------------------------------

        // AFTER: There's nothing to cleanup in this fixutre
    }, { auto: true }],
})

export { expect };